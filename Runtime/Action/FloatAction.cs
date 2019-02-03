﻿namespace Zinnia.Action
{
    using UnityEngine.Events;
    using System;
    using Malimbe.XmlDocumentationAttribute;
    using Zinnia.Extension;

    /// <summary>
    /// Emits a <see cref="float"/> value.
    /// </summary>
    public class FloatAction : Action<FloatAction, float, FloatAction.UnityEvent>
    {
        /// <summary>
        /// Defines the event with the <see cref="float"/> state.
        /// </summary>
        [Serializable]
        public class UnityEvent : UnityEvent<float>
        {
        }

        /// <summary>
        /// The tolerance of equality between two <see cref="float"/> values.
        /// </summary>
        [DocumentedByXml]
        public float equalityTolerance = float.Epsilon;

        /// <inheritdoc />
        protected override bool IsValueEqual(float value)
        {
            return Value.ApproxEquals(value, equalityTolerance);
        }

        /// <inheritdoc />
        protected override bool ShouldActivate(float value)
        {
            return !defaultValue.ApproxEquals(value, equalityTolerance);
        }
    }
}