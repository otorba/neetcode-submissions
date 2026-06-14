class Node:
    def __init__(self, key: int, value: int) -> None:
        self._key = key
        self._value = value
        self._prev: "Node | None" = None
        self._next: "Node | None" = None

    @property
    def key(self) -> int:
        return self._key

    @property
    def value(self) -> int:
        return self._value

    @value.setter
    def value(self, value: int) -> None:
        self._value = value

    @property
    def prev(self) -> "Node | None":
        return self._prev

    @prev.setter
    def prev(self, prev: "Node | None"):
        self._prev = prev

    @property
    def next(self) -> "Node | None":
        return self._next

    @next.setter
    def next(self, next: "Node | None"):
        self._next = next


class DoubleLinkedList:
    def __init__(self) -> None:
        self._head: "Node | None" = None
        self._tail: "Node | None" = None

    def push_back(self, node: Node) -> None:
        if not self._head:
            self._head = self._tail = node
        else:
            self._tail.next = node
            node.prev = self._tail
            self._tail = node

    def pop_back(self) -> "Node":
        if self._head is None or self._head.next is None:
            raise ValueError()

        node = self._tail

        node.prev.next = None
        self._tail = node.prev

        node.prev = None
        node.next = None
        return node

    def pop_front(self):
        if self._head is None:
            raise ValueError()

        node = self._head
        self._head = self._head.next
        if self._head is not None:
            self._head.prev = None

        node.next = None
        return node

    def remove(self, node: Node) -> None:
        if not node.prev:
            self._head = node.next
            if self._head is None:
                self._tail = None
            else:
                node.next.prev = None
            node.next = None
        elif not node.next:
            node.prev.next = None
            self._tail = node.prev
            node.prev = None
        else:
            node.prev.next = node.next
            node.next.prev = node.prev
            node.next = None
            node.prev = None

    def items(self):
        nodes = []
        node = self._head
        while node is not None:
            nodes.append(node)
            node = node.next
        return nodes


class LRUCache:
    def __init__(self, capacity: int):
        self._capacity: int = capacity
        self._dll: DoubleLinkedList = DoubleLinkedList()
        self._dict: dict[int, Node] = {}  # int : Node(Key, Value, Prev, Next)

    def get(self, key: int) -> int:
        if key not in self._dict:
            return -1
        else:
            node = self._dict[key]
            self._dll.remove(node)
            self._dll.push_back(node)
            return node.value

    def put(self, key: int, value: int) -> None:
        if key not in self._dict:
            node = Node(key, value)
            self._dict[key] = node
            self._dll.push_back(node)
        else:
            node = self._dict[key]
            node.value = value
            self._dll.remove(node)
            self._dll.push_back(node)

        if len(self._dict) > self._capacity:
            node = self._dll.pop_front()
            self._dict.pop(node.key)
