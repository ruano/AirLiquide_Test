using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace AirLiquide_Test.API.Configuration.ErrorResponses
{
    public class CustomBadRequestResponse
    {
        public List<CustomBadRequestFieldError> Errors { get; set; }

        public CustomBadRequestResponse(ActionContext context)
        {
            Errors = new List<CustomBadRequestFieldError>();

            foreach (KeyValuePair<string, ModelStateEntry> keyModelStatePair in context.ModelState)
            {
                CustomBadRequestFieldError customBadRequestFieldError = new();
                customBadRequestFieldError.Field = keyModelStatePair.Key;

                ModelErrorCollection errors = keyModelStatePair.Value.Errors;
                foreach (ModelError error in errors)
                {
                    customBadRequestFieldError.Messages.Add(error.ErrorMessage);
                }

                Errors.Add(customBadRequestFieldError);
            }
        }
    }

    public class CustomBadRequestFieldError
    {
        public CustomBadRequestFieldError()
        {
            Messages = new List<string>();
        }

        public string Field { get; set; }
        public List<string> Messages { get; set; }
    }
}