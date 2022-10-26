namespace klaviyo.net
{
    public class NotRequiredProperty
    {
        public NotRequiredProperty(string name, object value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; private set; }
        public object Value { get; private set; }
    }
}