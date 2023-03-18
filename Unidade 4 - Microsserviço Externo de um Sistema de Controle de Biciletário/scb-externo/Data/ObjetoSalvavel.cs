namespace scb_externo.Data
{
    public class ObjetoSalvavel
    {
        private ExternoContext Context;

        public ObjetoSalvavel(ExternoContext context)
        {
            Context = context;
        }
        public ObjetoSalvavel() { }

        public void Save(ObjetoSalvavel obj)
        {
            Context.Add(obj);
            Context.SaveChanges();
        }
    }
}
