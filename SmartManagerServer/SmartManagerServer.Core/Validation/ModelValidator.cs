using SmartManagerServer.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartManagerServer.Core.Validation
{
    public class ModelValidator
    {
        private readonly ICollection<IValidationRule> rules;
        public ICollection<ModelValidationError> ValidationErrors { get; private set; }
        public bool Valid { get; private set; }
        public ModelValidator()
        {
            rules = new List<IValidationRule>();
            ValidationErrors = new List<ModelValidationError>();
        }

        public ModelValidator AddRule(IValidationRule rule)
        {
            rules.Add(rule);
            return this;
        }

        public ModelValidator AddError(ModelValidationError error)
        {
            ValidationErrors.Add(error);
            return this;
        }

        public ModelValidationResult Validate(bool throwExceptionIfAnyError = true)
        {
            foreach (var rule in rules)
            {
                bool validationResult = rule.Validate();
                if (validationResult == false)
                {
                    ValidationErrors.Add(rule.ValidationError);
                }
            }

            string errorMessage = string.Empty;
            if (ValidationErrors.Any() == true)
            {
                Valid = true;
                errorMessage = string.Join(" ", ValidationErrors.Select(x => x.Message));

                if (throwExceptionIfAnyError)
                {
                    throw new ModelValidationException(errorMessage);
                }
            }

            return new ModelValidationResult(Valid, errorMessage);
        }
    }
}
