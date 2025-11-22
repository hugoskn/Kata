def solution(N):
    binary = bin(N)[2:]
    print(binary)

    max_gap = 0
    current_gap = 0
    for x in binary:
        if x == '0':
            current_gap += 1
            continue
        if x == '1':
            if current_gap > max_gap:
                max_gap = current_gap
            current_gap = 0            
    return max_gap
