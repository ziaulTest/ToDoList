using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using toDoList.Api.Models;


namespace ToDoList.Validation
{
    public class ToDoListValidator : AbstractValidator<toDoList.Api.Models.toDoList>
    {
        public ToDoListValidator()
        {
            this.CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(t => t.task).NotNull().MaximumLength(100);
            RuleFor(p => p.priority).NotNull();
            RuleFor(s => s.status).NotNull();


        }

       
    }
}
