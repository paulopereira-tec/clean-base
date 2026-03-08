using FluentValidation;

namespace CleanBase.Business.Features.ToDoItems.CreateToDoItem
{
  /// <summary>
  /// Validator for CreateToDoItemCommand.
  /// Validador para o comando de criação.
  /// </summary>
  public class CreateToDoItemValidator : AbstractValidator<CreateToDoItemCommand>
  {
    public CreateToDoItemValidator()
    {
      RuleFor(x => x.Title)
          .NotEmpty().WithMessage("Title is required / O título é obrigatório")
          .MaximumLength(100);

      RuleFor(x => x.Description)
          .MaximumLength(500);
    }
  }
}
