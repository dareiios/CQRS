using CQRSMediator.Entities;
using CQRSMediator.Interfaces;
using FluentValidation;
using MediatR;

namespace CQRSMediator.Queries.Reminders.GetReminderTag
{
    public class GetReminderTagHandler : IRequestHandler<GetReminderTagQuery, ReminderTag?>
    {
        private readonly IReminderRepository _reminderRepository;
        private readonly IValidator<GetReminderTagQuery> _validator;

        public GetReminderTagHandler(IReminderRepository reminderRepository, IValidator<GetReminderTagQuery> validator)
        {
            _reminderRepository = reminderRepository;
            _validator = validator;
        }

        public async Task<ReminderTag?> Handle(GetReminderTagQuery request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);
            return await _reminderRepository.GetReminderTagById(request.ReminderId);
        }
    }
}
