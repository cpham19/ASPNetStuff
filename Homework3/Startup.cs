using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Homework3.Services;

namespace Homework3
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<IForumService, ForumService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                // Main Page where you see all forums
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Forum}/{action=Index}/{id?}");

                // View selected forum and its topics
                routes.MapRoute(
                    name: "ViewForum",
                    defaults: new { controller = "Forum", action = "ViewForum"},
                    template: "Forum/View/{id?}");

                // View selected topic and its replies
                routes.MapRoute(
                    name: "ViewTopic",
                    defaults: new { controller = "Forum", action = "ViewTopic",},
                    template: "Forum/View/{id?}/{id2?}");

                // Adding a new forum
                routes.MapRoute(
                    name: "AddForum",
                    defaults: new { controller = "Forum", action = "AddForum"},
                    template: "Forum/Add");

                // Adding a new topic for selected forum
                routes.MapRoute(
                    name: "AddTopic",
                    defaults: new { controller = "Forum", action = "AddTopic"},
                    template: "Forum/View/{id?}/AddTopic");

                // Adding a new reply for selected topic
                routes.MapRoute(
                    name: "AddReply",
                    defaults: new { controller = "Forum", action = "AddReply" },
                    template: "Forum/View/{id?}/{id2?}/AddReply");
            });
        }
    }
}
