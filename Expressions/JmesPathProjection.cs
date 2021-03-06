﻿using DevLab.JmesPath.Utils;
using Newtonsoft.Json.Linq;

namespace DevLab.JmesPath.Expressions
{
    public abstract class JmesPathProjection : JmesPathExpression
    {
        public abstract JmesPathArgument Project(JmesPathArgument argument);

        protected override JmesPathArgument Transform(JToken json)
        {
            return Project(json);
        }
    }
}