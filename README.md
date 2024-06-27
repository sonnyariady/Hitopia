# Hitopia
HITOPIA - Problem Solving Test

Run the application then select the menu:
Select 1 for Weighted Strings
Select 2 for Balanced Bracket 
Select 3 for Highest Palindrome
Select 4 for Exit menu and application

README Entry for Complexity Analysis
Complexity Analysis
Time Complexity
The time complexity of the AreBracketsBalanced function is O(n), where n is the length of the input string. This is because we iterate through each character of the string exactly once. Each character is either pushed onto or popped from the stack, and both of these operations are O(1). Therefore, the overall time complexity is linear in relation to the size of the input.

Space Complexity
The space complexity of the AreBracketsBalanced function is O(n), where n is the length of the input string. In the worst-case scenario, all characters in the string could be opening brackets, and they would all be pushed onto the stack. This means that the maximum space required for the stack is proportional to the number of characters in the input string.

This approach ensures efficient and reliable checking of balanced brackets with minimal complexity.
