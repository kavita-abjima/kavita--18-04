

namespace CSNullBasics
{
    class Message
    {
        public string ? From { get; set; }
        public string Text { get; set; } = "";
        public string ? ToUpperFrom()=> From ?.ToUpperInvariant();
        //public string ToUpperFrom()
        //{
        //    if (From is null)
        //    {
        //        return " ";
        //    }
        //    return From.ToUpperInvariant();
        //}
    }
}
