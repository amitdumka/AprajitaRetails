namespace AprajitaRetails.Utils
{
    internal class Controls
    {
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public override string ToString( )
        {
            return Text;
        }
    }
}