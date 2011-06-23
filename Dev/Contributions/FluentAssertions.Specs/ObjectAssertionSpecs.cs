﻿using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentAssertions.Specs
{
    [TestClass]
    public class ObjectAssertionSpecs
    {
        #region Be / NotBe

        [TestMethod]
        public void When_two_equal_object_are_expected_to_be_equal_it_should_not_throw()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var someObject = new ClassWithCustomEqualMethod(1);
            var equalObject = new ClassWithCustomEqualMethod(1);

            //-------------------------------------------------------------------------------------------------------------------
            // Act / Assert
            //-------------------------------------------------------------------------------------------------------------------
            someObject.Should().Be(equalObject);
        }

        [TestMethod]
        public void When_two_different_objects_are_expected_to_be_equal_it_should_throw_with_a_clear_explanation()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var someObject = new ClassWithCustomEqualMethod(1);
            var nonEqualObject = new ClassWithCustomEqualMethod(2);

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            Action act = () => someObject.Should().Be(nonEqualObject);

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected object to be ClassWithCustomEqualMethod(2), but found ClassWithCustomEqualMethod(1).");
        }

        [TestMethod]
        public void When_both_subject_and_expected_are_null_it_should_succeed()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            object someObject = null;
            object expectedObject = null;

            //-------------------------------------------------------------------------------------------------------------------
            // Act / Assert
            //-------------------------------------------------------------------------------------------------------------------
            someObject.Should().Be(expectedObject);
        }

        [TestMethod]
        public void When_the_subject_is_null_it_should_throw()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            object someObject = null;
            var nonEqualObject = new ClassWithCustomEqualMethod(2);

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            Action act = () => someObject.Should().Be(nonEqualObject);

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>()
                .WithMessage("Expected object to be ClassWithCustomEqualMethod(2), but found <null>.");
        }

        [TestMethod]
        public void When_two_different_objects_are_expected_to_be_equal_it_should_throw_and_use_the_reason()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var someObject = new ClassWithCustomEqualMethod(1);
            var nonEqualObject = new ClassWithCustomEqualMethod(2);

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            Action act = () => someObject.Should().Be(nonEqualObject, "because it should use the {0}", "reason");

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>()
                .WithMessage(
                    "Expected object to be ClassWithCustomEqualMethod(2) because it should use the reason, but found ClassWithCustomEqualMethod(1).");
        }

        [TestMethod]
        public void When_non_equal_objects_are_expected_to_be_not_equal_it_should_not_throw()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var someObject = new ClassWithCustomEqualMethod(1);
            var nonEqualObject = new ClassWithCustomEqualMethod(2);

            //-------------------------------------------------------------------------------------------------------------------
            // Act / Assert
            //-------------------------------------------------------------------------------------------------------------------
            someObject.Should().NotBe(nonEqualObject);
        }

        [TestMethod]
        public void When_two_equal_objects_are_expected_not_to_be_equal_it_should_throw_with_a_clear_explanation()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var someObject = new ClassWithCustomEqualMethod(1);
            var equalObject = new ClassWithCustomEqualMethod(1);

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () =>
                someObject.Should().NotBe(equalObject);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Did not expect object to be equal to ClassWithCustomEqualMethod(1).");
        }

        [TestMethod]
        public void When_two_equal_objects_are_expected_not_to_be_equal_it_should_throw_and_use_the_reason()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var someObject = new ClassWithCustomEqualMethod(1);
            var equalObject = new ClassWithCustomEqualMethod(1);

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () =>
                someObject.Should().NotBe(equalObject, "because we want to test the failure {0}", "message");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Did not expect object to be equal to ClassWithCustomEqualMethod(1) " +
                    "because we want to test the failure message.");
        }

        #endregion

        #region Same / NotSame

        [TestMethod]
        public void When_same_objects_are_expected_to_be_the_same_it_should_not_throw()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var someObject = new ClassWithCustomEqualMethod(1);
            var sameObject = someObject;

            //-------------------------------------------------------------------------------------------------------------------
            // Act / Arrange
            //-------------------------------------------------------------------------------------------------------------------
            someObject.Should().BeSameAs(sameObject);
        }

        [TestMethod]
        public void When_two_different_objects_are_expected_to_be_the_same_it_should_throw_with_a_clear_explanation()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var someObject = new ClassWithCustomEqualMethod(1);
            var someOtherObject = new ClassWithCustomEqualMethod(2);

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            Action act = () => someObject.Should().BeSameAs(someOtherObject);

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>()
                .WithMessage("Expected the exact same objects.");
        }

        [TestMethod]
        public void When_two_different_objects_are_expected_to_be_the_same_it_should_throw_and_use_the_reason()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var someObject = new ClassWithCustomEqualMethod(1);
            var someOtherObject = new ClassWithCustomEqualMethod(2);

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            Action act = () => someObject.Should().BeSameAs(someOtherObject, "the are {0} {1}", "not", "the same");

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>()
                .WithMessage("Expected the exact same objects because the are not the same.");
        }

        [TestMethod]
        public void When_two_different_objects_are_expected_not_to_be_the_same_it_should_not_throw()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var someObject = new ClassWithCustomEqualMethod(1);
            var notSameObject = new ClassWithCustomEqualMethod(1);

            //-------------------------------------------------------------------------------------------------------------------
            // Act / Assert
            //-------------------------------------------------------------------------------------------------------------------
            someObject.Should().NotBeSameAs(notSameObject);
        }

        [TestMethod]
        public void When_two_equal_object_are_expected_not_to_be_the_same_it_should_throw()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var someObject = new ClassWithCustomEqualMethod(1);
            ClassWithCustomEqualMethod sameObject = someObject;

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            Action act = () => someObject.Should().NotBeSameAs(sameObject, "they are {0} {1}", "the", "same");

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>()
                .WithMessage("Expected different objects because they are the same.");
        }

        #endregion

        [TestMethod]
        public void Should_succeed_when_asserting_null_object_to_be_null()
        {
            object someObject = null;
            someObject.Should().BeNull();
        }

        [TestMethod]
        [ExpectedException(typeof (AssertFailedException))]
        public void Should_fail_when_asserting_non_null_object_to_be_null()
        {
            var someObject = new object();
            someObject.Should().BeNull();
        }

        [TestMethod]
        public void When_a_non_null_object_is_expected_to_be_null_it_should_throw()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var someObject = new object();
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action act = () => someObject.Should().BeNull("because we want to test the failure {0}", "message");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            act
                .ShouldThrow<AssertFailedException>()
                .Where(e => e.Message.StartsWith("Expected <null> because we want to test the failure message, but found System.Object"));
        }

        [TestMethod]
        public void Should_succeed_when_asserting_non_null_object_not_to_be_null()
        {
            var someObject = new object();
            someObject.Should().NotBeNull();
        }

        [TestMethod]
        [ExpectedException(typeof (AssertFailedException))]
        public void Should_fail_when_asserting_null_object_not_to_be_null()
        {
            object someObject = null;
            someObject.Should().NotBeNull();
        }

        [TestMethod]
        public void Should_fail_with_descriptive_message_when_asserting_null_object_not_to_be_null()
        {
            object someObject = null;
            var assertions = someObject.Should();
            assertions.Invoking(x => x.NotBeNull("because we want to test the failure {0}", "message"))
                .ShouldThrow<AssertFailedException>()
                .WithMessage("Expected non-null value because we want to test the failure message, but found <null>.");
        }

        [TestMethod]
        public void When_the_object_type_is_exactly_equal_to_the_specified_type_it_should_not_throw()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var someObject = new Exception();

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            Action act = () => someObject.Should().BeOfType<Exception>();

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            act.ShouldNotThrow();
        }

        [TestMethod]
        public void When_object_type_is_different_than_expected_type_it_should_throw()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var someObject = new object();

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            Action act = () => someObject.Should().BeOfType<int>("because they are {0} {1}", "of different", "type");

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected type System.Int32 because they are of different type, but found System.Object.");
        }

        [TestMethod]
        public void When_object_type_is_a_subclass_of_the_expected_type_it_should_throw()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var someObject = new DummyImplementingClass();

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            Action act = () => someObject.Should().BeOfType<DummyBaseClass>();

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>().WithMessage(
                "Expected type FluentAssertions.Specs.DummyBaseClass, but found FluentAssertions.Specs.DummyImplementingClass.");
        }

        [TestMethod]
        public void Should_fail_with_descriptive_message_when_asserting_object_type_to_be_equal_to_a_different_type()
        {
            var someObject = new object();
            var assertions = someObject.Should();
            assertions
                .Invoking(x => x.BeOfType<Exception>("because we want to test the failure {0}", "message"))
                .ShouldThrow<AssertFailedException>()
                .WithMessage(
                    "Expected type System.Exception because we want to test the failure message, but found System.Object.");
        }

        [TestMethod]
        public void Should_succeed_when_asserting_object_assignable_to_for_same_type()
        {
            var someObject = new DummyImplementingClass();
            someObject.Should().BeAssignableTo<DummyImplementingClass>();
        }

        [TestMethod]
        public void Should_succeed_when_asserting_object_assignable_to_base_type()
        {
            var someObject = new DummyImplementingClass();
            someObject.Should().BeAssignableTo<DummyBaseClass>();
        }

        [TestMethod]
        public void Should_succeed_when_asserting_object_assignable_to_implemented_interface_type()
        {
            var someObject = new DummyImplementingClass();
            someObject.Should().BeAssignableTo<IDisposable>();
        }

        [TestMethod]
        public void Should_fail_with_descriptive_message_when_asserting_object_assignable_to_not_implemented_type()
        {
            var someObject = new DummyImplementingClass();

            someObject.Invoking(
                x => x.Should().BeAssignableTo<DateTime>("because we want to test the failure {0}", "message"))
                .ShouldThrow<AssertFailedException>()
                .WithMessage(string.Format(
                    "Expected to be assignable to {1} because we want to test the failure message, but {0} does not implement {1}",
                    typeof (DummyImplementingClass), typeof (DateTime)));
        }

        [TestMethod]
        public void Should_support_chaining_constraints_with_and()
        {
            var someObject = new Exception();
            someObject.Should()
                .BeOfType<Exception>()
                .And
                .NotBeNull();
        }
    }

    internal class ClassWithCustomEqualMethod
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref = "T:System.Object" /> class.
        /// </summary>
        public ClassWithCustomEqualMethod(int key)
        {
            Key = key;
        }

        private int Key { get; set; }

        private bool Equals(ClassWithCustomEqualMethod other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return other.Key == Key;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != typeof (ClassWithCustomEqualMethod))
            {
                return false;
            }
            return Equals((ClassWithCustomEqualMethod) obj);
        }

        public override int GetHashCode()
        {
            return Key;
        }

        public static bool operator ==(ClassWithCustomEqualMethod left, ClassWithCustomEqualMethod right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ClassWithCustomEqualMethod left, ClassWithCustomEqualMethod right)
        {
            return !Equals(left, right);
        }

        /// <summary>
        ///   Returns a <see cref = "T:System.String" /> that represents the current <see cref = "T:System.Object" />.
        /// </summary>
        /// <returns>
        ///   A <see cref = "T:System.String" /> that represents the current <see cref = "T:System.Object" />.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return string.Format("ClassWithCustomEqualMethod({0})", Key);
        }
    }

    internal class DummyBaseClass
    {
    }

    internal class DummyImplementingClass : DummyBaseClass, IDisposable
    {
        public void Dispose()
        {
            // Ignore
        }
    }
}