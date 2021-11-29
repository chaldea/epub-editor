let editorInstance;
export function createEditor(eleEditor, eleToolbar) {
    DecoupledEditor
        .create(eleEditor)
        .then(editor => {
            editorInstance = editor;
            eleToolbar.append(editor.ui.view.toolbar.element);
        })
        .catch(error => {
            console.error(error);
        });
}

export function setEditorData(html) {
    if (editorInstance) {
        editorInstance.setData(html);
    }
}

export function getEditorData() {
    if (editorInstance) {
        return editorInstance.getData();
    }
    return '';
}

export function split(ele1, ele2) {
    window.Split([ele1, ele2], {
        gutterSize: 1,
        sizes: [25, 75]
    })
}
