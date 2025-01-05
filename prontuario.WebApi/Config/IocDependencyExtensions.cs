using prontuario.Application.Gateways;
using prontuario.Application.Usecases.AccessCode;
using prontuario.Application.Usecases.Auth;
using prontuario.Application.Usecases.Patient;
using prontuario.Application.Usecases.User;
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
            
            // Users
            services.AddScoped<IUserGateway, UserRepositoryGateway>();
            services.AddScoped<FindUserByEmail>();
            services.AddScoped<CreateUserUseCase>();
            services.AddScoped<CreateAccessCodeUseCase>();
            services.AddScoped<UpdateUserPasswordUseCase>();

            // Auth
            services.AddScoped<Login>();
            
            // Outros serviços
            services.AddScoped<IBcryptGateway, BcryptServiceGateway>();
            services.AddScoped<ITokenGateway, TokenGateway>();
        }
    }
}
