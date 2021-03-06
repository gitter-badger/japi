﻿using FluentAssertions;
using Newtonsoft.Json.Linq;
using System;
using Xunit;

namespace JApi
{
    /// <summary>
    /// http://jsonapi.org/format/#document-jsonapi-object
    /// MAY and MUST rules for all JApiObject instances
    /// </summary>
    public class JApiObjects
    {
        [Fact]
        public void MayContainAMetaObject()
        {
            var instance = new JApiObject(meta: new JObject(new JProperty("some", "thing")));
            var result = instance.ToString(Newtonsoft.Json.Formatting.None);
            result.Should().Be("{\"meta\":{\"some\":\"thing\"}}");
        }

        [Fact]
        public void MayContainAMetaObjectThatIsEmpty()
        {
            var instance = new JApiObject(meta: new JObject());
            var result = instance.ToString(Newtonsoft.Json.Formatting.None);
            result.Should().Be("{\"meta\":{}}");
        }

        [Fact]
        public void MayContainAMetaObjectThatNests()
        {
            var instance = new JApiObject(meta: new JObject(new JProperty("some", new JObject(new JProperty("nested", "thing")))));
            var result = instance.ToString(Newtonsoft.Json.Formatting.None);
            result.Should().Be("{\"meta\":{\"some\":{\"nested\":\"thing\"}}}");
        }

        [Fact]
        public void MayContainAVersion()
        {
            var instance = new JApiObject(version: "1.0");
            var result = instance.ToString(Newtonsoft.Json.Formatting.None);
            result.Should().Be("{\"version\":\"1.0\"}");
        }

        [Fact]
        public void MayContainAVersionButWillIgnoreEmpty()
        {
            var instance = new JApiObject(version: "");
            var result = instance.ToString(Newtonsoft.Json.Formatting.None);
            result.Should().Be("{}");
        }

        [Fact]
        public void MayContainAVersionButWillIgnoreNull()
        {
            var instance = new JApiObject(version: null);
            var result = instance.ToString(Newtonsoft.Json.Formatting.None);
            result.Should().Be("{}");
        }

        [Fact]
        public void MayContainAVersionButWillIgnoreWhiteSpace()
        {
            var instance = new JApiObject(version: " ");
            var result = instance.ToString(Newtonsoft.Json.Formatting.None);
            result.Should().Be("{}");
        }

        [Fact]
        public void MustBeAnObject()
        {
            var instance = new JApiObject();
            var result = instance.ToString();
            result.Should().Be("{}");
        }
    }
}