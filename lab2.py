def kruskals_algorithm(adjacency_matrix):
    vertex_count = len(adjacency_matrix)
    parent_nodes = list(range(vertex_count))
    tree_rank = [0] * vertex_count

    def find_root(node):
        while parent_nodes[node] != node:
            parent_nodes[node] = parent_nodes[parent_nodes[node]]
            node = parent_nodes[node]
        return node

    edge_list = []
    for start in range(vertex_count):
        for end in range(start + 1, vertex_count):
            weight = adjacency_matrix[start][end]
            if weight > 0:
                edge_list.append((weight, start, end))
    
    edge_list.sort()

    total_weight = 0
    edges_added_count = 0
    
    for weight, start_vertex, end_vertex in edge_list:
        start_root = find_root(start_vertex)
        end_root = find_root(end_vertex)
        
        if start_root != end_root:
            if tree_rank[start_root] > tree_rank[end_root]:
                parent_nodes[end_root] = start_root
            else:
                parent_nodes[start_root] = end_root
                if tree_rank[start_root] == tree_rank[end_root]:
                    tree_rank[end_root] += 1
            
            total_weight += weight
            edges_added_count += 1
            
            if edges_added_count == vertex_count - 1:
                break

    return total_weight


def prims_algorithm(adjacency_matrix):
    total_weight = 0
    visited_vertices = [1]
    
    while len(visited_vertices) < len(adjacency_matrix):
        current_min_edge = float('inf')
        selected_vertex = None
        
        for current_vertex in visited_vertices:
            row_index = current_vertex - 1
            for neighbor_index, edge_weight in enumerate(adjacency_matrix[row_index]):
                target_vertex = neighbor_index + 1
                
                if (edge_weight > 0 and 
                    edge_weight < current_min_edge and 
                    target_vertex not in visited_vertices):
                    
                    current_min_edge = edge_weight
                    selected_vertex = target_vertex
        
        if selected_vertex is not None:
            visited_vertices.append(selected_vertex)
            total_weight += current_min_edge
    
    return total_weight


adjacency_matrix = [
    [0, 1, 0, 1, 0],
    [1, 0, 1, 0, 1],
    [0, 1, 0, 1, 0],
    [1, 0, 1, 0, 1],
    [0, 1, 0, 1, 0]
]

kruskal_result = kruskals_algorithm(adjacency_matrix)
prim_result = prims_algorithm(adjacency_matrix)

print(f"Вес минимального остовного дерева (Крускал): {kruskal_result}")
print(f"Вес минимального остовного дерева (Прим): {prim_result}")
