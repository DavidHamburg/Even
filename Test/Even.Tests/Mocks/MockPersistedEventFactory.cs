using NSubstitute;

namespace Even.Tests.Mocks
{
    public class MockPersistedEventFactory : IPersistedEventFactory
    {
        public IPersistedEvent CreateEvent(IPersistedRawEvent rawEvent)
        {
            var e = Substitute.For<IPersistedEvent>();

            e.GlobalSequence.Returns(rawEvent.GlobalSequence);

            return e;
        }

        public IPersistedStreamEvent CreateStreamEvent(IPersistedRawEvent rawEvent, int streamSequence)
        {
            var e = Substitute.For<IPersistedStreamEvent>();

            e.GlobalSequence.Returns(rawEvent.GlobalSequence);
            e.Stream.Returns(rawEvent.Stream);
            e.StreamSequence.Returns(streamSequence);

            return e;
        }
    }
}
