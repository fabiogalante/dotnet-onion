using System.Reflection;
using Dotnet.Onion.Template.API.Configuration;
using Dotnet.Onion.Template.API.Extensions.Middleware;
using Dotnet.Onion.Template.Application.Handlers;
using Dotnet.Onion.Template.Application.Mappers;
using Dotnet.Onion.Template.Domain.Tasks;
using Dotnet.Onion.Template.Domain.Tasks.Commands;
using Dotnet.Onion.Template.Domain.Tasks.Events;
using Dotnet.Onion.Template.Infrastructure.Factories;
using Dotnet.Onion.Template.Infrastructure.Repositories;
using FluentMediator;
using Jaeger;
using Jaeger.Samplers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenTracing;
using OpenTracing.Util;

namespace Dotnet.Onion.Template.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            
            services.AddTransient<ITaskRepository, TaskRepository>(); //just as an example, you may use it as .AddScoped
            services.AddSingleton<TaskViewModelMapper>();
            services.AddTransient<ITaskFactory, EntityFactory>();

            

            services.AddScoped<TaskCommandHandler>();
            services.AddScoped<TaskEventHandler>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddFluentMediator(builder =>
            {
                builder.On<CreateNewTaskCommand>().PipelineAsync().Return<Domain.Tasks.Task, TaskCommandHandler>((handler, request) => handler.HandleNewTask(request));

                builder.On<TaskCreatedEvent>().PipelineAsync().Call<TaskEventHandler>((handler, request) => handler.HandleTaskCreatedEvent(request));

                builder.On<DeleteTaskCommand>().PipelineAsync().Call<TaskCommandHandler>((handler, request) => handler.HandleDeleteTask(request));

                builder.On<TaskDeletedEvent>().PipelineAsync().Call<TaskEventHandler>((handler, request) => handler.HandleTaskDeletedEvent(request));
            });

            services.AddSingleton(serviceProvider =>
            {
                var serviceName = Assembly.GetEntryAssembly().GetName().Name;

                var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

                ISampler sampler = new ConstSampler(true);

                ITracer tracer = new Tracer.Builder(serviceName)
                    .WithLoggerFactory(loggerFactory)
                    .WithSampler(sampler)
                    .Build();

                GlobalTracer.Register(tracer);

                return tracer;
            });


            services.ResolveDependencies();

            services.AddOpenTracing();

            services.AddOptions();

            services.AddMvc();

            services.AddSwaggerGen();

            #region Logging

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConfiguration(Configuration.GetSection("Logging"));
                loggingBuilder.AddConsole();
                loggingBuilder.AddDebug();
                loggingBuilder.AddLog4Net();
            });

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<ExceptionMiddleware>();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Tasks API V1");
            });
        }
    }
}
