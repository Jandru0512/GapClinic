namespace Gap.Clinic.Repositories
{
    using System.Collections.Generic;
    using System.Text;
    using Services;

    public class Include : IInclude
    {
        #region Constructor

        public Include()
        {
            _inclutions = new List<string>();
        }

        #endregion

        #region Atributos Privados

        private readonly List<string> _inclutions;

        #endregion

        #region Métodos Públicos

        public void Add(params string[] inclutions)
        {
            StringBuilder strBuilder = new StringBuilder();

            for (int index = 0; index < inclutions.Length; index++)
            {
                strBuilder.Append(index == inclutions.Length - 1 ? inclutions[index] : inclutions[index] + ".");
            }

            _inclutions.Add(strBuilder.ToString());
        }

        public string Get()
        {
            return string.Join(",", _inclutions);
        }

        public void Clear()
        {
            _inclutions.Clear();
        }

        #endregion
    }
}
