from ArrayCyclicRotation import solution
from stopwatch import Stopwatch

sw = Stopwatch()
sw.start()

result = solution([3, 8, 9, 7, 6], 3)
print("\nResult=",result)

result = solution([3, 8, 9, 7, 6, 5], 3)
print("\nResult=",result)

sw.stop()
print("\n",sw.duration * 1000, "ms")
print("\nResult=",result)
