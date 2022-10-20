using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AsciiString_UdemyDPAdditional_ConsoleApp
{
    // ASCII string
    public class str : IEquatable<str>
    {
        [NotNull] protected readonly byte[] buffer;
        public bool Equals(str other)
        {
            if (other == null) return false;
            return ((IStructuralEquatable)buffer)
              .Equals(other.buffer,
                StructuralComparisons.StructuralEqualityComparer); // this makes sure that the comparison is done sort of element by element.
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((str)obj);
        }
        public str()
        {
            buffer = new byte[] { };
        }
        // utf16 convert to ASCII
        public str(string s)
        {
            buffer = Encoding.ASCII.GetBytes(s);
        }
        protected str(byte[] buffer)
        {
            this.buffer = buffer;
        }
        public static implicit operator str(string s)
        {
            return new str(s);
        }
        public static bool operator ==(str left, str right)
        {
            return Equals(left, right);

        }
        public static bool operator !=(str left, str right)
        {
            return !Equals(left, right);
        }
        public static str operator +(str first, str second)
        {
            var bytes = new byte[
                first.buffer.Length + second.buffer.Length];
            first.buffer.CopyTo(bytes, 0);
            second.buffer.CopyTo(bytes, first.buffer.Length);
            return new str(bytes);
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public override string ToString()
        {
            return Encoding.ASCII.GetString(buffer); 
        }
        public char this[int index]
        {
            get => (char)buffer[index];
            set => buffer[index] = (byte)value;
        }
       
    }
}
