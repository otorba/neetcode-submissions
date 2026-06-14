from dataclasses import dataclass


@dataclass
class Node:
    key: int
    value: int
    prev: "Node | None" = None
    next: "Node | None" = None


class DoublyLinkedList:
    def __init__(self) -> None:
        self._head: "Node | None" = None
        self._tail: "Node | None" = None

    def append(self, node: Node) -> None:
        if not self._head:
            self._head = self._tail = node
        else:
            self._tail.next = node
            node.prev = self._tail
            self._tail = node

    def popLeft(self):
        if self._head is None:
            raise ValueError()

        node = self._head
        self._head = self._head.next
        if self._head is not None:
            self._head.prev = None

        node.next = None
        return node

    def unlink(self, node: Node) -> None:
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
        self._dll: DoublyLinkedList = DoublyLinkedList()
        self._dict: dict[int, Node] = {}  # int : Node(Key, Value, Prev, Next)

    def get(self, key: int) -> int:
        if key not in self._dict:
            return -1
        else:
            node = self._dict[key]
            self._dll.unlink(node)
            self._dll.append(node)
            return node.value

    def put(self, key: int, value: int) -> None:
        if key not in self._dict:
            node = Node(key, value)
            self._dict[key] = node
            self._dll.append(node)
        else:
            node = self._dict[key]
            node.value = value
            self._dll.unlink(node)
            self._dll.append(node)

        if len(self._dict) > self._capacity:
            node = self._dll.popLeft()
            self._dict.pop(node.key)
