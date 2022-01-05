using P01.Logger.Models.Contracts;

namespace P01.Logger.Models.Layout
{
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
