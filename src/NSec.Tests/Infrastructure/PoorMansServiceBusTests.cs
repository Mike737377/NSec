using NSec.Infrastructure;
using NSubstitute;
using Ploeh.AutoFixture.Xunit;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Extensions;

namespace NSec.Tests.Infrastructure
{
    public class PoorMansServiceBusTests
    {
        public class TestMessage { }

        public class TestMessageHandler : IHandler<TestMessage>
        {
            public bool Executed { get; private set; }

            public void Execute(TestMessage message)
            {
                Executed = true;
            }
        }

        [Theory, AutoData]
        public void Send_WithTestMessage_HandlesTestMessage(TestMessage message, TestMessageHandler handler)
        {
            var handlerRegistry = Substitute.For<IHandlerRegistry>();
            handlerRegistry.GetHandlerForMessage<TestMessage>().Returns(handler);

            PoorMansServiceBus sut = new PoorMansServiceBus(handlerRegistry);
            sut.Send(message);

            handler.Executed.ShouldBe(true);
        }
    }
}