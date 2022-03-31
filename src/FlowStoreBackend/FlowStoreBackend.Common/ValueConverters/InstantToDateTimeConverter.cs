using AutoMapper;
using NodaTime;

namespace FlowStoreBackend.Common.ValueConverters
{
    public class InstantToDateTimeConverter : IValueConverter<Instant, DateTime>
    {
        public DateTime Convert(Instant sourceMember, ResolutionContext context)
        {
            return sourceMember.ToDateTimeUtc();
        }
    }
}
