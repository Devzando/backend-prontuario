using prontuario.Application.Gateways;
using prontuario.Application.Usecases.Patient;
using prontuario.Infra.Gateways;

namespace prontuario.WebApi.Config
{
    public static class IocDependencyExtensions
    {
        public static void AddIocDependencies(this IServiceCollection services)
        {
            // Patients
            services.AddScoped<IGatewayPatient, PatientRepositoryGateway>();
            services.AddScoped<CreatePatientUseCase>();
            services.AddScoped<GetAllPatientsUseCase>();
            services.AddScoped<GetPatientsByFilterUseCase>();
        }
    }
}
