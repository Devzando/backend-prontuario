using prontuario.Application.Gateways;
using prontuario.Application.Usecases.AccessCode;
using prontuario.Application.Usecases.Auth;
using prontuario.Application.Usecases.MedicalRecord;
using prontuario.Application.Usecases.Patient;
using prontuario.Application.Usecases.PatientExam;
using prontuario.Application.Usecases.PatientMonitoring;
using prontuario.Application.Usecases.Service;
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
            services.AddScoped<UpdatePatientStatusUseCase>();
            services.AddScoped<FindAllPatientUseCase>();
            services.AddScoped<UpdatePatientUseCase>();
            services.AddScoped<FindPatientByIdUseCase>();
            
            // Users
            services.AddScoped<IUserGateway, UserRepositoryGateway>();
            services.AddScoped<FindUserByEmail>();
            services.AddScoped<CreateUserUseCase>();
            services.AddScoped<CreateAccessCodeUseCase>();
            services.AddScoped<UpdateUserPasswordUseCase>();

            // Services
            services.AddScoped<IServiceGateway, ServiceRepositoryGateway>();
            services.AddScoped<InitializeServiceUseCase>();
            services.AddScoped<InitializeScreeningUseCase>();
            services.AddScoped<FindAllServicesByPatientIdUseCase>();
            
            // Profiles
            services.AddScoped<IProfileGateway, ProfileRepositoryGateway>();
            
            // MedicalRecord
            services.AddScoped<IMedicalRecordGateway, MedicalRecordRepositoryGateway>();
            services.AddScoped<CreateAnamneseUseCase>();
            services.AddScoped<AddPatientMonitoringUseCase>();
            services.AddScoped<AddPatientExamUseCase>();
            services.AddScoped<FinalizePatientExamUseCase>();
            services.AddScoped<FindMedicalRecordByIdUseCase>();
            
            // Auth
            services.AddScoped<Login>();
            
            // Nursing 
            services.AddScoped<INursingGateway, NursingRepositoryGateway>();
            services.AddScoped<CreateNursingNoteUseCase>();
            services.AddScoped<FindAllNursingNoteUseCase>();

            // Outros serviços
            services.AddScoped<IBcryptGateway, BcryptServiceGateway>();
            services.AddScoped<ITokenGateway, TokenGateway>();

            //PatientExams
            services.AddScoped<IPatientExamGateway, PatientExamRepositoryGateway>();
        }
    }
}
