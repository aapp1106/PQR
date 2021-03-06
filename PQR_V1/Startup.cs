using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PQR_V1.Model;
using PQR_V1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PQR_V1
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
			// requires using Microsoft.Extensions.Options
			services.Configure<PQRstoreDatabaseSettings>(
			    Configuration.GetSection(nameof(PQRstoreDatabaseSettings)));

			services.AddSingleton<IPQRstoreDatabaseSettings>(sp =>
			    sp.GetRequiredService<IOptions<PQRstoreDatabaseSettings>>().Value);

			services.AddSingleton<PQRService>();
			services.AddSingleton<ReclamoService>();

			services.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseCors(builder => builder
			   .AllowAnyHeader()
			   .AllowAnyMethod()
			   .SetIsOriginAllowed((host) => true)
			   .AllowCredentials()
		     );

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
