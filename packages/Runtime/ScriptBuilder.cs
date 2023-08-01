using System.Text;

namespace Katuusagi.ScriptGenerator
{
    public class ScriptBuilder
    {
        private StringBuilder _builder = new StringBuilder();
        private int _indent = 0;

        public void Append(string str)
        {
            if (_builder.Length > 0 &&
                _builder[_builder.Length - 1] == '\n')
            {
                for (int i = 0; i < _indent; ++i)
                {
                    _builder.Append("    ");
                }
            }

            _builder.Append(str);
        }

        public void AppendLine(string str = "")
        {
            if (_builder.Length > 0 &&
                _builder[_builder.Length - 1] == '\n')
            {
                for (int i = 0; i < _indent; ++i)
                {
                    _builder.Append("    ");
                }
            }

            _builder.AppendLine(str);
        }

        public void RemoveBack(int count)
        {
            _builder = _builder.Remove(_builder.Length - count, count);
        }

        public void StartScope()
        {
            AppendLine("{");
            IncrementIndent();
        }

        public void EndScope()
        {
            DecrementIndent();
            AppendLine("}");
        }

        public void IncrementIndent()
        {
            ++_indent;
        }

        public void DecrementIndent()
        {
            --_indent;
        }

        public override string ToString()
        {
            return _builder.ToString();
        }
    }
}
