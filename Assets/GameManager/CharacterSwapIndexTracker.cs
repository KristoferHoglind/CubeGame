public static class CharacterSwapIndexTracker {

    public static int CurrentId { get; set; }

    public static int LastId { get; set; }

    public static void MoveToNextId() {
        if(IsLastId()) {
            CurrentId = 0;
        } else {
            CurrentId++;
        }
    }

    public static void MoveToPrevId() {
        if(IsFirstId()) {
            CurrentId = LastId;
        } else {
            CurrentId--;
        }
    }

    private static bool IsLastId() {
        if(CurrentId == LastId) {
            return true;
        }
        return false;
    }

    private static bool IsFirstId() {
        if(CurrentId == 0) {
            return true;
        }
        return false;
    }

}
