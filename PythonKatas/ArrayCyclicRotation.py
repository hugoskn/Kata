def solution(A, K):
    if K == 0 or A is None or len(A) <= 1:
        return A
    if len(A) <= K:
        first_num_index = K % len(A)
        if first_num_index == 0:
            return A
    else:
        first_num_index = K

    aux_index = 0
    index_to_replace = K
    for i in range(len(A) - 1):
        if aux_index >= len(A):
            break
        swap(A, aux_index, index_to_replace)
        index_to_replace = index_to_replace + K if index_to_replace + K < len(A) else ((index_to_replace + K) - len(A))
        if index_to_replace == aux_index:
            i+=1
            aux_index +=1
            if aux_index == K:
                break
            index_to_replace = aux_index + K if aux_index + K < len(A) else ((aux_index + K) - len(A))

    return A
        
def swap(A, i, j):
    aux = A[i]
    A[i] = A[j]
    A[j] = aux