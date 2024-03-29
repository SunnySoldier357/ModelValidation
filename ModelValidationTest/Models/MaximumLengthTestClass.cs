﻿using ModelValidation;

namespace ModelValidationTest.Models
{
    public class MaximumLengthTestClass : ValidatableObject
    {
        //* Public Properties
        [MaximumLength(10)]
        public string Value { get; set; }

        //* Constructors
        public MaximumLengthTestClass(string value) =>
            Value = value;
    }
}