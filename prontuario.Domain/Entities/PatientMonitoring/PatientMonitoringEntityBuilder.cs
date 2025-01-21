using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prontuario.Domain.Entities.PatientMonitoring
{
    public class PatientMonitoringEntityBuilder
    {
        private long _id;
        private string _bloodPressure = string.Empty;
        private string _glucose = string.Empty;
        private string _temperature = string.Empty;
        private string _saturation = string.Empty;
        private string _respiratoryRate = string.Empty;

        public PatientMonitoringEntityBuilder WithId(long id)
        {
            _id = id;
            return this;
        }

        public PatientMonitoringEntityBuilder WithBloodPressure(string bloodPressure)
        {
            _bloodPressure = bloodPressure;
            return this;
        }

        public PatientMonitoringEntityBuilder WithGlucose(string glucose)
        {
            _glucose = glucose;
            return this;
        }

        public PatientMonitoringEntityBuilder WithTemperature(string temperature)
        {
            _temperature = temperature;
            return this;
        }

        public PatientMonitoringEntityBuilder WithSaturation(string saturation)
        {
            _saturation = saturation;
            return this;
        }

        public PatientMonitoringEntityBuilder WithRespiratoryRate(string respiratoryRate)
        {
            _respiratoryRate = respiratoryRate;
            return this;
        }

        public PatientMonitoringEntity Build()
        {
            return new PatientMonitoringEntity(_id, _bloodPressure, _glucose, _temperature, _saturation, _respiratoryRate);
        }
    }

}
