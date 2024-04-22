using CQRSMediator.Entities;
using CQRSMediator.Interfaces;
using FluentValidation;
using MediatR;

namespace CQRSMediator.Commands.Reminders.BindTags
{
    public class BindTagsToReminderHandler : IRequestHandler<BindTagsToReminderCommand, IEnumerable<ReminderTag>?>
    {
        private readonly IReminderRepository _reminderRepository;
        private readonly IValidator<BindTagsToReminderCommand> _validator;


        public BindTagsToReminderHandler(IReminderRepository reminderRepository, IValidator<BindTagsToReminderCommand> validator)
        {
            _reminderRepository = reminderRepository;
            _validator = validator;
        }

        public async Task<IEnumerable<ReminderTag>?> Handle(BindTagsToReminderCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);
            return await _reminderRepository.Bind(request.ReminderId, request.TagsIds);
        }
    }
}
