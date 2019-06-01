﻿using ModelValidation;

namespace ModelValidationTest.Models
{
    public class MinimumLengthTestClass : ValidatableObject
    {
        //* Public Properties
        [MinimumLength(10)]
        public string Name { get; set; }

        //* Constructors
        public MinimumLengthTestClass(string name) =>
            Name = name;
    }
}
