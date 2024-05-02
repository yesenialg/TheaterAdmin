using FluentValidation;

namespace TheaterAdmin.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        public CreateEventCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Name} no puede estar en blanco")
                .NotNull()
                .MaximumLength(50).WithMessage("{Nombre} no puede exceder los 50 caracteres");

            RuleFor(p => p.ManagerId)
                 .NotEmpty().WithMessage("{ManagerId} no puede estar en blanco")
                 .NotNull();
        }
    }
}
