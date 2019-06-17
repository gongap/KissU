"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const schematics_1 = require("@angular-devkit/schematics");
const change_1 = require("@schematics/angular/utility/change");
const parse5 = require("parse5");
/** Gets the app index.html file */
function getIndexHtmlPath(host, project) {
    const buildTarget = (project.targets || project.architect).build.options;
    if (buildTarget.index && buildTarget.index.endsWith('index.html')) {
        return buildTarget.index;
    }
    throw new schematics_1.SchematicsException('No index.html file was found.');
}
exports.getIndexHtmlPath = getIndexHtmlPath;
/**
 * Parses the index.html file to get the HEAD tag position.
 */
function getTag(host, src, tagName) {
    if (parse5.treeAdapters) {
        return getTagInV4(host, src, tagName);
    }
    const document = parse5.parse(src, {
        sourceCodeLocationInfo: true,
    });
    let resNode;
    const visit = (nodes) => {
        nodes.forEach(node => {
            const element = node;
            if (element.nodeName === tagName) {
                resNode = element;
            }
            else {
                if (element.childNodes) {
                    visit(element.childNodes);
                }
            }
        });
    };
    visit(document.childNodes);
    if (!resNode) {
        throw new schematics_1.SchematicsException('Head element not found!');
    }
    return {
        startOffset: resNode.sourceCodeLocation.startTag.endOffset,
        endOffset: resNode.sourceCodeLocation.endTag.startOffset,
    };
}
exports.getTag = getTag;
function getTagInV4(host, src, tagName) {
    const document = parse5.parse(src, {
        locationInfo: true,
    });
    let resNode;
    const visit = (nodes) => {
        nodes.forEach(node => {
            const element = node;
            if (element.tagName === tagName) {
                resNode = element;
            }
            else {
                if (element.childNodes) {
                    visit(element.childNodes);
                }
            }
        });
    };
    visit(document.childNodes);
    if (!resNode) {
        throw new schematics_1.SchematicsException('Head element not found!');
    }
    return {
        startOffset: resNode.__location.startTag.endOffset,
        endOffset: resNode.__location.endTag.startOffset,
    };
}
exports.getTagInV4 = getTagInV4;
/**
 * Get index.html content
 */
function getIndexHtmlContent(host, project) {
    const indexPath = getIndexHtmlPath(host, project);
    const buffer = host.read(indexPath);
    if (!buffer) {
        throw new schematics_1.SchematicsException(`Could not find file for path: ${indexPath}`);
    }
    return {
        indexPath,
        src: buffer.toString(),
    };
}
exports.getIndexHtmlContent = getIndexHtmlContent;
/**
 * Adds a link to the index.html head tag
 */
function addHeadLink(host, project, link) {
    const { indexPath, src } = getIndexHtmlContent(host, project);
    if (src.indexOf(link) === -1) {
        const node = getTag(host, src, 'head');
        const insertion = new change_1.InsertChange(indexPath, node.startOffset, link);
        const recorder = host.beginUpdate(indexPath);
        recorder.insertLeft(insertion.pos, insertion.toAdd);
        host.commitUpdate(recorder);
    }
}
exports.addHeadLink = addHeadLink;
/**
 * Adds a style to the index.html head end tag
 */
function addHeadStyle(host, project, style) {
    const { indexPath, src } = getIndexHtmlContent(host, project);
    if (src.indexOf(style) === -1) {
        const node = getTag(host, src, 'head');
        const insertion = new change_1.InsertChange(indexPath, node.endOffset, style);
        const recorder = host.beginUpdate(indexPath);
        recorder.insertLeft(insertion.pos, insertion.toAdd);
        host.commitUpdate(recorder);
    }
}
exports.addHeadStyle = addHeadStyle;
/**
 * Adds a html to the index.html body end tag
 */
function addHtmlToBody(host, project, html) {
    const { indexPath, src } = getIndexHtmlContent(host, project);
    if (src.indexOf(html) === -1) {
        const node = getTag(host, src, 'body');
        const insertion = new change_1.InsertChange(indexPath, node.endOffset, html);
        const recorder = host.beginUpdate(indexPath);
        recorder.insertLeft(insertion.pos, insertion.toAdd);
        host.commitUpdate(recorder);
    }
}
exports.addHtmlToBody = addHtmlToBody;
//# sourceMappingURL=html.js.map