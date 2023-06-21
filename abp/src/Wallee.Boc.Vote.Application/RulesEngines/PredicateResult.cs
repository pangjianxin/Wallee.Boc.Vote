namespace Wallee.Boc.Vote.RulesEngines
{
    public class PredicateResult
    {
        public PredicateResult(string predicate, params object[] parameters)
        {
            Predicate = predicate;
            Parameters = parameters;
        }
        public string Predicate { get; set; }
        public object[] Parameters { get; set; }

        public static PredicateResult GetResult(string predicate, params object[] parameters)
        {
            return new PredicateResult(predicate, parameters);
        }
    }
}
