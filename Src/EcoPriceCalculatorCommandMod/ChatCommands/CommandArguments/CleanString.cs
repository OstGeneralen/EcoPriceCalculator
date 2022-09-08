namespace EPC.CommandMod.ChatCommands.CommandArguments
{
    /// <summary>
    /// Simple string type that ensures that the string used contains no leading or tailing white spaces
    /// </summary>
    internal class CleanString
    {
        public CleanString(string s)
        {
            _str = s.Trim();
        }

        public static implicit operator string(CleanString cs) => cs._str;
        public static implicit operator CleanString(string s) => new CleanString(s);

        private string _str;
    }
}
