using prontuario.Domain.Enums;
using prontuario.Domain.Exceptions;

namespace prontuario.Domain.ValuesObjects;

public class Permission
{
    public string Value { get; private set; }

    public Permission(string value)
    {
        if(!Enum.IsDefined(typeof(PermissionType), value))
            throw new DomainException("A permissão deve ser um dos seguintes valores:" +
                                      " AccessInitialPatientData, " +
                                      "EditPatientPersonalInformation, " +
                                      "AccessHealthData, " +
                                      "DownloadCompletedMedicalRecord, " +
                                      "FullSystemAccess, " +
                                      "AccessPatientData, " +
                                      "AccessHealthFeatures, " +
                                      "FullAccessToEverything, " +
                                      "ManageUsers, " +
                                      "ManageSystemConfigurations.");
        Value = value;
    }
}