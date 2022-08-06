using UnityEngine;

namespace Unity.VisualScripting
{
#if MODULE_PHYSICS_2D_EXISTS
    [UnitCategory("Events/Physics 2D")]
    public abstract class CollisionEvent2DUnit : GameObjectEventUnit<Collision2D>
    {
        /// <summary>
        /// The collider we hit.
        /// </summary>
        [DoNotSerialize]
        public ValueOutput collider { get; private set; }

        /// <summary>
        /// The contact points generated by the physics engine.
        /// </summary>
        [DoNotSerialize]
        public ValueOutput contacts { get; private set; }

        /// <summary>
        /// The relative linear velocity of the two colliding objects.
        /// </summary>
        [DoNotSerialize]
        public ValueOutput relativeVelocity { get; private set; }

        /// <summary>
        /// Whether the collision was enabled or not.
        /// </summary>
        [DoNotSerialize]
        public ValueOutput enabled { get; private set; }

        /// <summary>
        /// The complete collision data object.
        /// </summary>
        [DoNotSerialize]
        public ValueOutput data { get; private set; }

        protected override void Definition()
        {
            base.Definition();
            collider = ValueOutput<Collider2D>(nameof(collider));
            contacts = ValueOutput<ContactPoint2D[]>(nameof(contacts));
            relativeVelocity = ValueOutput<Vector2>(nameof(relativeVelocity));
            enabled = ValueOutput<bool>(nameof(enabled));
            data = ValueOutput<Collision2D>(nameof(data));
        }

        protected override void AssignArguments(Flow flow, Collision2D collisionData)
        {
            flow.SetValue(collider, collisionData.collider);
            flow.SetValue(contacts, collisionData.contacts);
            flow.SetValue(relativeVelocity, collisionData.relativeVelocity);
            flow.SetValue(enabled, collisionData.enabled);
            flow.SetValue(data, collisionData);
        }
    }
#endif
}
