﻿using System;
using Newtonsoft.Json.Linq;

namespace DevLab.JmesPath.Expressions
{
    public class JmesPathIndexExpression : JmesPathExpression
    {
        private readonly JmesPathExpression expression_;
        private readonly JmesPathExpression specifier_;

        public JmesPathIndexExpression(JmesPathExpression expression, JmesPathNumber index)
            : this(expression, new JmesPathIndex(index))
        {
        }

        public JmesPathIndexExpression(JmesPathExpression expression, JmesPathExpression specifier)
        {
            if (specifier == null) throw new ArgumentNullException(nameof(specifier));

            expression_ = expression;
            specifier_ = specifier;
        }

        public override bool IsProjection
            => specifier_.IsProjection
            ;

        protected override JToken Transform(JToken json)
        {
            var token = expression_?.Transform(json) ?? json;
            return token == null ? null : specifier_.Transform(token)?.Token;
        }
    }
}