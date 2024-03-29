﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace ModelValidation
{
    public abstract class ValidatableObject : INotifyPropertyChanged
    {
        //* Private Properties
        protected List<string> errors;

        //* Public Properties

        /// <summary>
        /// A List of all the error messages due to invalid properties.
        /// </summary>
        public List<string> Errors
        {
            get => errors;
            set => modifyProperty(ref value, ref errors, nameof(Errors));
        }

        //* Events
        public event PropertyChangedEventHandler PropertyChanged;

        //* Constructors
        public ValidatableObject() => Errors = new List<string>();

        //* Public Methods

        /// <summary>
        /// Validates this class or any of its subclasses, ensuring that any
        /// property that has an attribute that derives from
        /// ValidatablePropertyAttribute is valid.
        /// </summary>
        /// <returns>
        /// A boolean representing if all the class' properties are valid.
        /// </returns>
        public bool Validate()
        {
            bool result = true;
            List<string> tempErrors = new List<string>();
            PropertyInfo[] properties = GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                var attributes = getAttributes(property.Name);

                if (attributes != null)
                {
                    foreach (var attribute in attributes)
                    {
                        dynamic value = Convert.ChangeType(property.GetValue(this),
                            property.PropertyType);

                        bool tempResult = attribute.Validate<ValidatableObject, dynamic>(
                            this, value, property.Name, out string errorMessage);

                        if (!tempResult)
                        {
                            tempErrors.Add(errorMessage);
                            result = false;
                        }
                    }
                }
            }

            Errors = tempErrors;
            return result;
        }

        //* Event Handlers
        public void OnNotifyPropertyChanged(string property) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        //* Protected Methods
        protected void modifyProperty<T>(ref T value, ref T privateProperty, string nameOfProperty)
        {
            if (!value.Equals(privateProperty))
            {
                privateProperty = value;
                OnNotifyPropertyChanged(nameOfProperty);
            }
        }

        //* Private Methods
        private IEnumerable<ValidatablePropertyAttribute> getAttributes(string propertyName)
        {
            var result = new List<ValidatablePropertyAttribute>();

            object[] attributes = GetType().GetProperty(propertyName)
                .GetCustomAttributes(false);

            foreach (object attribute in attributes)
            {
                if (attribute is ValidatablePropertyAttribute attr)
                    result.Add(attr);
            }

            return result.Count == 0 ? null : result;
        }
    }
}