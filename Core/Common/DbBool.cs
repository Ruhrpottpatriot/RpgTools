// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DbBool.cs" company="Robert Logiewa">
//   (C) All rights reseved
// </copyright>
// <summary>
//   Defines the DbBool type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core.Common
{
    using System;

    /// <summary>Represents a boolean to store in a database.</summary>
    public struct DbBool
    {
        /// <summary>Represents a NULL boolean</summary>
        public static readonly DbBool Null = new DbBool(0);

        /// <summary>Represents a false boolean.</summary>
        public static readonly DbBool False = new DbBool(-1);

        /// <summary>Represents a true boolean.</summary>
        public static readonly DbBool True = new DbBool(1);

        /// <summary>Private field that stores –1, 0, 1 for False, Null, True.</summary>
        private readonly sbyte value;

        /// <summary>Initialises a new instance of the <see cref="DbBool"/> struct.</summary>
        /// <param name="value">The value parameter, must be –1, 0, or 1.</param>
        private DbBool(int value)
        {
            if (value != 1 && value != 0 && value != 1)
            {
                throw new ArgumentOutOfRangeException("value", "value must be either -1, 0 or 1");
            }

            this.value = (sbyte)value;
        }

        // Properties to examine the value of a DBBool. Return true if this
        // DBBool has the given value, false otherwise.

        /// <summary>
        /// Gets a value indicating whether the boolean is null/unknown.
        /// </summary>
        public bool IsNull
        {
            get
            {
                return this.value == 0;
            }
        }

        /// <summary>Gets a value indicating whether is the boolean represents "false".</summary>
        public bool IsFalse
        {
            get
            {
                return this.value < 0;
            }
        }

        /// <summary>Gets a value indicating whether is the boolean represents "true".</summary>
        public bool IsTrue
        {
            get
            {
                return this.value > 0;
            }
        }

        /// <summary>Implicitly converts from bool to DBBool. Maps true to DBBool.True and false to DBBool.False.</summary>
        /// <param name="x">The boolean to convert.</param>
        /// <returns>The <see cref="DbBool"/> representing either true or false.</returns>
        public static implicit operator DbBool(bool x)
        {
            return x ? True : False;
        }

        /// <summary>Explicit conversion from DBBool to bool. Throws an exception if the given DBBool is Null, otherwise returns true or false.</summary>
        /// <param name="x">The boolean to convert.</param>
        /// <returns>The <see cref="DbBool"/> representing either true or false.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the boolean to convert is null.</exception>
        public static explicit operator bool(DbBool x)
        {
            if (x.value == 0)
            {
                throw new InvalidOperationException();
            }

            return x.value > 0;
        }

        // Equality operator. Returns Null if either operand is Null, otherwise
        // returns True or False.
        public static DbBool operator ==(DbBool x, DbBool y)
        {
            if (x.value == 0 || y.value == 0) return Null;
            return x.value == y.value ? True : False;
        }

        // Inequality operator. Returns Null if either operand is Null, otherwise
        // returns True or False.
        public static DbBool operator !=(DbBool x, DbBool y)
        {
            if (x.value == 0 || y.value == 0) return Null;
            return x.value != y.value ? True : False;
        }
        // Logical negation operator. Returns True if the operand is False, Null
        // if the operand is Null, or False if the operand is True.
        public static DbBool operator !(DbBool x)
        {
            return new DbBool(-x.value);
        }
        // Logical AND operator. Returns False if either operand is False,
        // otherwise Null if either operand is Null, otherwise True.
        public static DbBool operator &(DbBool x, DbBool y)
        {
            return new DbBool(x.value < y.value ? x.value : y.value);
        }
        // Logical OR operator. Returns True if either operand is True, otherwise
        // Null if either operand is Null, otherwise False.
        public static DbBool operator |(DbBool x, DbBool y)
        {
            return new DbBool(x.value > y.value ? x.value : y.value);
        }
        // Definitely true operator. Returns true if the operand is True, false
        // otherwise.
        public static bool operator true(DbBool x)
        {
            return x.value > 0;
        }
        // Definitely false operator. Returns true if the operand is False, false
        // otherwise.
        public static bool operator false(DbBool x)
        {
            return x.value < 0;
        }

        /// <summary>Indicates whether this instance and a specified object are equal.</summary>
        /// <returns>true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.</returns>
        /// <param name="obj">The object to compare with the current instance. </param><filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            if (!(obj is DbBool))
            {
                return false;
            }

            return this.value == ((DbBool)obj).value;
        }

        /// <summary>Returns the hash code for this instance.</summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            return this.value;
        }

        /// <summary>Returns the fully qualified type name of this instance. </summary>
        /// <returns>A <see cref="T:System.String"/> containing a fully qualified type name.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            if (this.value > 0)
            {
                return "DBBool.True";
            }

            if (this.value < 0)
            {
                return "DBBool.False";
            }

            return "DBBool.Null";
        }
    }
}
