﻿using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Moq;
using TinyBeans.Caching.Defaults;
using TinyBeans.Caching.Options;
using TinyBeans.Caching.Tests.Dummy;
using Xunit;

namespace TinyBeans.Caching.Tests.Defaults {
    public class DefaultCachingAspectTests {
        private readonly DefaultCachingSerializer _defaultCachingSerializer = new DefaultCachingSerializer();
        private readonly Mock<IDistributedCache> _distributedCacheMock = new Mock<IDistributedCache>();
        private readonly Mock<IOptionsMonitor<CachingOptions>> _optionsMonitorMock = new Mock<IOptionsMonitor<CachingOptions>>();

        private readonly CachingOptions _cachingOptions = new CachingOptions();
        private readonly byte[] _bytes = Encoding.UTF8.GetBytes("{\"Property1\":\"p1\",\"Property2\":\"p2\",\"Property3\":\"p3\"}");

        public DefaultCachingAspectTests() {
            _cachingOptions.AbsoluteExpiration = TimeSpan.FromSeconds(5);
            _cachingOptions.SlidingExpiration = TimeSpan.FromMinutes(1);

            _distributedCacheMock.SetupSequence(x => x.Get(It.IsAny<string>())).Returns((byte[])null).Returns(_bytes).Returns(_bytes);
            _distributedCacheMock.SetupSequence(x => x.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult((byte[])null)).Returns(Task.FromResult(_bytes)).Returns(Task.FromResult(_bytes));
            _optionsMonitorMock.Setup(x => x.CurrentValue).Returns(_cachingOptions);
        }

        private DefaultCachingAspect Sut => new DefaultCachingAspect(_defaultCachingSerializer, _distributedCacheMock.Object, _optionsMonitorMock.Object);

        [Fact]
        public void ResultMethod() {
            var sut = Sut;
            var dummy = new DummyClass();

            _ = sut.Invoke("key", () => { return dummy.ResultMethod(); });
            _ = sut.Invoke("key", () => { return dummy.ResultMethod(); });
            _ = sut.Invoke("key", () => { return dummy.ResultMethod(); });

            _distributedCacheMock.Verify(x => x.Set(It.IsAny<string>(), It.IsAny<byte[]>(), It.IsAny<DistributedCacheEntryOptions>()), Times.Exactly(1));
        }

        [Fact]
        public void ResultMethodAsync() {
            var sut = Sut;
            var dummy = new DummyClass();

            _ = sut.InvokeAsync("key", () => { return dummy.ResultMethodAsync(); }).Result;
            _ = sut.InvokeAsync("key", () => { return dummy.ResultMethodAsync(); }).Result;
            _ = sut.InvokeAsync("key", () => { return dummy.ResultMethodAsync(); }).Result;

            _distributedCacheMock.Verify(x => x.SetAsync(It.IsAny<string>(), It.IsAny<byte[]>(), It.IsAny<DistributedCacheEntryOptions>(), It.IsAny<CancellationToken>()), Times.Exactly(1));
        }
    }
}
