namespace prontuario.WebApi.ResponseModels.PatientMonitoring
{
    public class PatientMonitoringResponseBuilder
    {
        private long _id;
        private string? _bloodPressure;
        private string? _glucose;
        private string? _temperature;
        private DateTime _monitoringDate;
        private string? _saturation;
        private string? _respiratoryRate;

        public PatientMonitoringResponseBuilder WithId(long id)
        {
            _id = id;
            return this;
        }

        public PatientMonitoringResponseBuilder WithBloodPressure(string? bloodPressure)
        {
            _bloodPressure = bloodPressure;
            return this;
        }

        public PatientMonitoringResponseBuilder WithGlucose(string? glucose)
        {
            _glucose = glucose;
            return this;
        }

        public PatientMonitoringResponseBuilder WithTemperature(string? temperature)
        {
            _temperature = temperature;
            return this;
        }

        public PatientMonitoringResponseBuilder WithMonitoringDate(DateTime monitoringDate)
        {
            _monitoringDate = monitoringDate;
            return this;
        }

        public PatientMonitoringResponseBuilder WithSaturation(string? saturation)
        {
            _saturation = saturation;
            return this;
        }

        public PatientMonitoringResponseBuilder WithRespiratoryRate(string? respiratoryRate)
        {
            _respiratoryRate = respiratoryRate;
            return this;
        }

        public PatientMonitoringResponse Build()
        {
            return new PatientMonitoringResponse(
                _id,
                _bloodPressure,
                _glucose,
                _temperature,
                _monitoringDate,
                _saturation,
                _respiratoryRate
            );
        }
    }
}
