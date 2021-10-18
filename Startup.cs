using ELearnApplication.Models;
using ELearnApplication.Repositary;
using ELearnApplication.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication
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
            services.AddControllersWithViews();

            services.AddScoped<IUserAccount<UserAccount>, UserAccount>();
            services.AddScoped<IRepo<UserAccount>, Repo>();
            services.AddScoped<IUserServ<UserAccount>, UserServ>();

            services.AddScoped<ICourse<Course>, Course>();
            services.AddScoped<IRepoCourse<Course>, RepoCourse>();
            services.AddScoped<ICourseServ<Course>, CourseServ>();

            services.AddScoped<INewStaff<NewStaff>, NewStaff>();
            services.AddScoped<IRepoNewStaff<NewStaff>, RepoNewStaff>();
            services.AddScoped<INewStaffServ<NewStaff>, NewStaffServ>();

            services.AddScoped<IContact<Contact>, Contact>();
            services.AddScoped<IContactRepo<Contact>, ContactRepo>();
            services.AddScoped<IContactServ<Contact>, ContactServ>();

            services.AddScoped<ICustomer<Customer>, Customer>();
            services.AddScoped<IRepoCustomer<Customer>, RepoCustomer>();
            services.AddScoped<ICustomerServ<Customer>, CustomerServ>();

            services.AddScoped<ICourseEnroll<CourseEnroll>, CourseEnroll>();
            services.AddScoped<IRepoCourseEnroll<CourseEnroll>, RepoCourseEnroll>();
            services.AddScoped<ICourseEnrollServ<CourseEnroll>, CourseEnrollServ>();

            services.AddScoped<ITopic<Topic>, Topic>();
            services.AddScoped<ITopicRepo<Topic>, TopicRepo>();
            services.AddScoped<ITopicServ<Topic>, TopicServ>();

            services.AddScoped<IClass<Class>, Class>();
            services.AddScoped<IClassRepo<Class>, ClassRepo>();
            services.AddScoped<IClassServ<Class>, ClassServ>();

            services.AddSession();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
