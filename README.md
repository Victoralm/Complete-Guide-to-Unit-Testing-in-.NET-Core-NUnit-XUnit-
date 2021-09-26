# [Complete Guide Unit Testing in .NET Core NUnit XUnit](https://www.udemy.com/course/complete-guide-to-unit-testing-in-net-core-nunit-xunit/) #

- [Course repository](https://github.com/bhrugen/Sparky)
- [Other Courses](https://www.dotnetmastery.com/#course)

## What is Automated Testing ##

Write code to test the code of yoru application, and then repeatedly run the
tests in automated fashion.

There will be two separated codes:

- The application code: for production / development
- The testing code: to test the application code

### Manual testing ###

- Not as efficient as Unit Testing
- In order to test a class logic, you might have to:
  - Launch the application
  - Login / Register
  - Navigate to the desired page
  - Populate details
  - Verify results

### Automated testing ###

- Write once, run often
- Execute anytime
- Catch bugs before deploying
- Very reliable and efficient
- Confidant deployment

### Types of tests ###

- Unit test:
  - May test a single class or perhaps a functionally related to a class
  - Offers the best depth of testing, but doesn't cover the entire system
  - Quickly to write and execution speed
- Integration test:
  - Potentially less in-depth than unit test, but covers a greater range of the system
  - Test the application with its external dependencies
  - Longer execution times, because of the external dependencies
- User Interface test:
  - Covers a great range of an application, from the user interface (like a
    buttom click) to all the way down through tha subsystem, even right down to
    the database level
  - Covers a wide range, but don't go in depth. Not all of classes, nor their
    functionalities or properties
  - The slowest of all tests
  - Very brittle, the smallest change can break the test, since it tests a wide
    range of functionalities

### Testing Pyramid ###

             = UI =
       === Integration ===
    ========== Unit =========

A final application should have all of the three tests, which is: Unit tests,
Integration tests and UI tests. But not exactly in equal proportion...
As shown in the pyramid, the biggest space is occupied by the Unit test. Then
the Integration tests, to give more confidence as compared to the Unit tests.
Finally, the smallest amount tha comprehends the UI tests.

Keep in mind that: more tests means more time consuming and more cost...

### Logical Phases of an Automated Test ###

The triple A (AAA):

- Arrange
  - Initial setup
  - Create object instances
  - Create test data
- Act
  - Execution of application code
  - Call methods
  - Set propreties
- Assert
  - Check results
  - Test pass / fail
