namespace Agenda_Consultorio_Odontologico.controller
{
    public class TimeIntervalController
    {
        private DateTime _I;
        private DateTime _F;

        public DateTime InicialDate
        {
            get { return _I; }
            private set { _I = value; }
        }

        public DateTime FinalDate
        {
            get { return _F; }
            private set
            {
                if (value >= _I)
                    _F = value;
                else throw new Exception("A data final não pode ser anterior à data inicial!");
            }
        }

        public TimeSpan Duration
        {
            get { return _F - _I; }
        }

        public TimeIntervalController(DateTime dateI, DateTime dateF)
        {
            _I = dateI;
            _F = dateF;
        }

        static public bool HasInersection(TimeIntervalController A, TimeIntervalController B)
        {
            return A.InicialDate <= B.FinalDate && B.InicialDate <= A.FinalDate;
        }

        static public bool IsEqual(TimeIntervalController A, TimeIntervalController B)
        {
            return A.InicialDate == B.InicialDate && A.FinalDate == B.FinalDate;
        }
    }
}
