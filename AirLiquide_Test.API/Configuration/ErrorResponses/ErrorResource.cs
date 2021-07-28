using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AirLiquide_Test.API.Configuration.ErrorResponses
{
    public class ErrorResource
    {
        public List<FieldErrorDetails> Errors { get; set; }

        public ErrorResource(ActionContext context)
        {
            Errors = new List<FieldErrorDetails>();

            foreach (KeyValuePair<string, ModelStateEntry> keyModelStatePair in context.ModelState)
            {
                FieldErrorDetails fieldErrorDetails = new();
                fieldErrorDetails.Field = keyModelStatePair.Key;

                ModelErrorCollection errors = keyModelStatePair.Value.Errors;
                foreach (ModelError error in errors)
                {
                    fieldErrorDetails.Messages.Add(error.ErrorMessage);
                }

                Errors.Add(fieldErrorDetails);
            }
        }

        public ErrorResource(string message)
        {
            FieldErrorDetails customBadRequestFieldError = new();
            customBadRequestFieldError.Messages.Add(message);

            Errors = new List<FieldErrorDetails> { customBadRequestFieldError };
        }
    }

    public class FieldErrorDetails
    {
        public FieldErrorDetails()
        {
            Messages = new List<string>();
        }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Field { get; set; }

        public List<string> Messages { get; set; }
    }
}