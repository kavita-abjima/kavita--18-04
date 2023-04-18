using System;
using System.Reflection;

namespace CSNullBasics
{
    internal class MessagePopulator
    {
        public static void Populate(Message message)
        {
            message.GetType().InvokeMember("From", BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty,
            Type.DefaultBinder, message, new[] { "Jason(set using reflection)" });
        }
    }
}
