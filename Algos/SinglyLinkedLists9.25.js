/**
 * A class to represents a single item of a SinglyLinkedList that can be
 * linked to other Node instances to form a list of linked nodes.
 */
class ListNode {
    /**
     * Constructs a new Node instance. Executed when the 'new' keyword is used.
     * @param {any} data The data to be added into this new instance of a Node.
     *    The data can be anything, just like an array can contain strings,
     *    numbers, objects, etc.
     * @returns {ListNode} A new Node instance is returned automatically without
     *    having to be explicitly written (implicit return).
     */
    constructor(data) {
        this.data = data;
        /**
         * This property is used to link this node to whichever node is next
         * in the list. By default, this new node is not linked to any other
         * nodes, so the setting / updating of this property will happen sometime
         * after this node is created.
         *
         * @type {ListNode|null}
       */
        this.next = null;
    }
}
/**
   * This class keeps track of the start (head) of the list and to store all the
   * functionality (methods) that each list should have.
   */
class SinglyLinkedList {
    /**
     * Constructs a new instance of an empty linked list that inherits all the
     * methods.
     * @returns {SinglyLinkedList} The new list that is instantiated is implicitly
     *    returned without having to explicitly write "return".
     */
    constructor() {
        /** @type {ListNode|null} */
        this.head = null;
    }
    /**
     * Determines if this list is empty.
     * - Time: O(?).
     * - Space: O(?).
     * @returns {boolean}
     */
    isEmpty() {
        return this.head == null;
    }
    /**
     * Creates a new node with the given data and inserts it at the back of
     * this list.
     * - Time: O(?).
     * - Space: O(?).
     * @param {any} data The data to be added to the new node.
     * @returns {SinglyLinkedList} This list.
     */
    insertAtBack(data) {
        let newEnd = new ListNode(data);
        if (this.isEmpty()) {
            this.head = newEnd;
            return this;
        }
        let runner = this.head;
        while (runner.next !== null) {
            runner = runner.next;
        }
        runner.next = newEnd;
        return this;
    }
    /**
     * Creates a new node with the given data and inserts it at the back of
     * this list.
     * - Time: O(?).
     * - Space: O(?).
     * @param {any} data The data to be added to the new node.
     * @param {?ListNode} runner The current node during the traversal of this list
     *    or null when the end of the list has been reached.
     * @returns {SinglyLinkedList} This list.
     */
    insertAtBackRecursive(data, runner = this.head) {
        if (this.head === null) {
            this.head = new ListNode(data);
            return this;
        }
        if (runner.next === null) {
            runner.next = new ListNode(data);
            return this;
        }
        return this.insertAtBackRecursive(data, runner.next);
    }
    /**
     * Calls insertAtBack on each item of the given array.
     * - Time: O(n * m) n = list length, m = arr.length.
     * - Space: O(1) constant.
     * @param {Array<any>} vals The data for each new node.
     * @returns {SinglyLinkedList} This list.
     */
    insertAtBackMany(vals) {
        for (const item of vals) {
            this.insertAtBack(item);
        }
        return this;
    }
    /**
     * Converts this list into an array containing the data of each node.
     * - Time: O(n) linear.
     * - Space: O(n).
     * @returns {Array<any>} An array of each node's data.
     */
    toArr() {
        const arr = [];
        let runner = this.head;
        while (runner) {
            arr.push(runner.data);
            runner = runner.next;
        }
        return arr;
    }
    /**
     * Creates a new node with the given data and inserts that node at the front
     * of this list.
     * - Time: (?).
     * - Space: (?).
     * @param {any} data The data for the new node.
     * @returns {SinglyLinkedList} This list.
     */
    insertAtFront(data) {
        let newHead = new ListNode(data);
        newHead.next = this.head;
        this.head = newHead;
        return this;
    }
    /**
     * Removes the first node of this list.
     * - Time: (?).
     * - Space: (?).
     * @returns {any} The data from the removed node or null if no first node.
     */
    removeHead() {
        if (this.isEmpty()) return null;
        let removed = this.head;
        this.head = this.head.next;
        return removed.data;
    }

    /**
     * Determines whether or not the given search value exists in this list iteratively.
     * - Time: O(?).
     * - Space: O(?).
     * @param {any} val The data to search for in the nodes of this list.
     * @returns {boolean}
    */
    contains(val) {
        let runner = this.head;
        while (runner) {
            if (runner.data === val) return true;
            runner = runner.next;
        }
        return false;
    }
    /**
     * Determines whether or not the given search value exists in this list recursively.
     * - Time: O(?).
     * - Space: O(?).
     * @param {any} val The data to search for in the nodes of this list.
     * @param {?ListNode} current The current node during the traversal of this list
     *    or null when the end of the list has been reached.
     * @returns {boolean}
    */
    containsRecursive(val, current = this.head) {
        if (!current) return false;
        if (current.data === val) return true;
        return this.containsRecursive(val, current.next);
    }
    /**
    * Removes the last node of this list.
    * - Time: O(?).
    * - Space: O(?).
    * @returns {any} The data from the node that was removed or null if no nodes were removed.
    */
    removeBack() {
        if (this.isEmpty()) {
            return null;
        }

        // only one node, remove the head
        if (this.head.next === null) {
            return this.removeHead();
        }
        //more than one node, move to one before the end
        let runner = this.head;
        while (runner.next.next) {
            runner = runner.next;
        }

        const removedData = runner.next.data;
        runner.next = null;
        return removedData;
    }
}
const emptyList = new SinglyLinkedList()
const singleNodeList = new SinglyLinkedList().insertAtBackMany([1]);
const biNodeList = new SinglyLinkedList().insertAtBackMany([1, 2]);
const firstThreeList = new SinglyLinkedList().insertAtBackMany([1, 2, 3]);
const secondThreeList = new SinglyLinkedList().insertAtBackMany([4, 5, 6]);
const unorderedList = new SinglyLinkedList().insertAtBackMany([
-5, -10, 4, -3, 6, 1, -7, -2,
]);

// ! contains
console.log(emptyList.contains(0)) // Should be false
console.log(unorderedList.contains(-2)) // Should be true
console.log(firstThreeList.contains(1)) // Should be true

// ! contains recursive
console.log(emptyList.containsRecursive(0)) // Should be false
console.log(unorderedList.containsRecursive(-2)) // Should be true
console.log(firstThreeList.containsRecursive(1)) // Should be true

// ! remove back
console.log(emptyList.removeBack()) // should be null
console.log(secondThreeList.removeBack()) //should be 6
console.log(secondThreeList.toArr()) // [4, 5]