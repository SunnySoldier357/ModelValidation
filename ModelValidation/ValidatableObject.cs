using System;
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
        public bool Validate()
        {
            bool result = true;
            List<string> tempErrors = new List<string>();
            PropertyInfo[] properties = GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                ValidatablePropertyAttribute attribute = getAttribute(property.Name);

                if (attribute != null)
                {
                    dynamic value = Convert.ChangeType(property.GetValue(this),
                        property.PropertyType);

                    bool tempResult = attribute.Validate<dynamic>(value, property.Name,
                        out string errorMessage);

                    if (!tempResult)
                    {
                        tempErrors.Add(errorMessage);
                        result = false;
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
        private ValidatablePropertyAttribute getAttribute(string propertyName)
        {
            object[] attributes = GetType().GetProperty(propertyName)
                .GetCustomAttributes(false);

            foreach (object attribute in attributes)
            {
                if (attribute is ValidatablePropertyAttribute attr)
                    return attr;
            }

            return null;
        }
    }
}